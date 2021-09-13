import { Component, OnInit } from '@angular/core';
import { ModalProvider } from 'src/app/providers/modal.provider';
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

  constructor(private service: ProductService, private modalProvider: ModalProvider) { }

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

  openModalLogs(log: number) {
    switch (log) {
      case 1:
        this.modalProvider.openModalLogs(1);
        break;
      case 2:
        this.modalProvider.openModalLogs(2);
        break;
    }
  }
}
