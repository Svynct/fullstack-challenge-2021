import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-servicos',
  templateUrl: './servicos.component.html',
  styleUrls: ['./servicos.component.css']
})
export class ServicosComponent implements OnInit {

  recuperarRunning: boolean = false;
  recuperarSuccess: boolean = false;
  recuperarCount: number = 0;

  deleteRunning: boolean = false;
  deleteSuccess: boolean = false;

  constructor(private service: ProductService) { }

  ngOnInit() {
  }

  recuperarProdutos() {

    this.recuperarRunning = true;
    this.recuperarSuccess = false;
    this.recuperarCount = 0;

    this.service.recuperarProductInfo().subscribe((res: any) => {
      if (res) {
        this.recuperarSuccess = true;
        this.recuperarCount = res.length;
        this.recuperarRunning = false;
      }
    })
  }

  deletarProdutos() {

    this.deleteRunning = true;
    this.deleteSuccess = false;

    this.service.deleteAllProducts().subscribe((res: any) => {
      if (res) {
        this.deleteSuccess = true;
        this.deleteRunning = false;
      }
    })
  }
}
