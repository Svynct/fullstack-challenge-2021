import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-editar-produto',
  templateUrl: './editar-produto.component.html',
  styleUrls: ['./editar-produto.component.css']
})
export class EditarProdutoComponent implements OnInit {

  produto: any;
  editado: boolean = false;
  msgErro: boolean = false;

  formulario: FormGroup;

  constructor(
    public bsModalRef: BsModalRef,
    private fb: FormBuilder,
    private service: ProductService
  ) { }

  ngOnInit() {
    this.formulario = this.fb.group({
      brands: [`${this.produto.brands}`, Validators.required],
      packaging: [`${this.produto.packaging}`, Validators.required],
      quantity: [`${this.produto.quantity}`, Validators.required],
      categories: [`${this.produto.categories}`, Validators.required]
    });
  }

  montarFiltro() {
    let filtro = this.formulario.value;

    return filtro;
  }

  editar() {
    this.msgErro = false;

    let filtro = this.montarFiltro();

    let obj = {
      code: this.produto.code,
      brands: filtro.brands,
      packaging: filtro.packaging,
      quantity: filtro.quantity,
      categories: filtro.categories,
    }

    this.service.updateOneProduct(obj).subscribe((res: any) => {
      if (res) {
        this.produto.brands = obj.brands;
        this.produto.packaging = obj.packaging;
        this.produto.quantity = obj.quantity;
        this.produto.categories = obj.categories;

        this.editado = true;

        this.bsModalRef.hide();
      }
      else {
        this.msgErro = true;
      }
    });
  }
}
