import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ProductService } from 'src/app/services/product.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-novo-produto',
  templateUrl: './novo-produto.component.html',
  styleUrls: ['./novo-produto.component.css']
})
export class NovoProdutoComponent implements OnInit {

  formulario: FormGroup;
  msgErro: boolean = false;
  success: boolean = false;

  constructor(
    private fb: FormBuilder,
    public bsModalRef: BsModalRef,
    private service: ProductService) { }

  ngOnInit() {
    this.formulario = this.fb.group({
      brands: ["", Validators.required],
      packaging: ["", Validators.required],
      quantity: ["", Validators.required],
      categories: ["", Validators.required],
      url: ["", Validators.required],
      image_url: ["", Validators.required],
      code: ["", Validators.required],
      product_name: ["", Validators.required],
    });
  }

  montarFiltro() {
    let filtro = this.formulario.value;

    return filtro;
  }

  cadastrar() {
    let filtro = this.montarFiltro();

    let obj = {
      code: Number(filtro.code),
      product_name: filtro.product_name,
      brands: filtro.brands,
      packaging: filtro.packaging,
      quantity: filtro.quantity,
      categories: filtro.categories,
      url: filtro.url,
      image_url: filtro.image_url,
      barcode: filtro.code + " (EAN / EAN-13)",
      status: 0,
      imported_t: null
    }

    this.service.createProduct(obj).subscribe(() => {
      this.success = true;
      this.bsModalRef.hide();
    }, err => {
      Swal.fire(
        "Erro",
        "Houve um erro ao cadastrar o produto",
        "error"
      )
    })
  }
}
