import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ModalProvider } from 'src/app/providers/modal.provider';
import { ProductService } from 'src/app/services/product.service';
import Swal from 'sweetalert2';

interface Filtro {
  Status?: string,
  Barcode?: string,
  Nome?: string
}

@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.css']
})

export class ProdutosComponent implements OnInit {

  formulario: FormGroup;
  listaSearch: any[];
  searching: boolean = false;

  constructor(
    private fb: FormBuilder,
    private service: ProductService,
    private modalProvider: ModalProvider) { }

  ngOnInit() {
    this.formulario = this.fb.group({
      barcode: [""],
      status: ["Todos"],
      nome: [""]
    });
  }

  montarFiltro() {
    let filtro: Filtro = {
      Status: this.formulario.get("status").value,
      Barcode: this.formulario.get("barcode").value,
      Nome: this.formulario.get("nome").value
    }

    return filtro;
  }

  buscar() {
    this.listaSearch = [];

    let filtro = this.montarFiltro();

    this.searching = true;

    this.service.getProductByFiltro(filtro).subscribe((res: any) => {
      if (res) this.listaSearch = res;
      this.searching = false;
    });
  }

  openModalEditar(produto: any) {
    this.modalProvider.openModalEditarProduto(produto).then((res: any) => {
      if (res.editado) {
        this.buscar();
      }
    })
  }

  openModalNovoProduto() {
    this.modalProvider.openModalNovoProduto().then((res: any) => {
      if (res.success) {
        this.buscar();
      }
    })
  }

  openModalExcluir(produto: any) {
    Swal.fire({
      title: 'Remover',
      text: 'Você tem certeza que deseja remover este produto?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sim',
      cancelButtonText: 'Não'
    }).then((result) => {
      if (result.isConfirmed) {
        this.service.deleteProduct(produto.id).subscribe((res: any) => {
          if (res) {
            Swal.fire(
              'Removido!',
              `O produto ${produto.code} foi removido com sucesso`,
              'success'
            )
            this.listaSearch = this.listaSearch.filter(p => p.id != produto.id);
          }
        }, err => {
          Swal.fire(
            'Erro',
            `Houve um erro ao remover o produto`,
            'error'
          )
        })
      }
    })
  }
}
