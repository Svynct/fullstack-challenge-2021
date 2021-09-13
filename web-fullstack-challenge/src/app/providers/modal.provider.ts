import { Injectable } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { take } from 'rxjs/operators';
import { EditarProdutoComponent } from '../pages/produtos/editar-produto/editar-produto.component';
import { NovoProdutoComponent } from '../pages/produtos/novo-produto/novo-produto.component';
import { LogsModalComponent } from '../pages/servicos/logs-modal/logs-modal.component';

@Injectable({
  providedIn: 'root'
})
export class ModalProvider {

  modalRef: BsModalRef;

  constructor(
    private modalService: BsModalService
  ) { }

  openModalEditarProduto(produto: any = null) {
    return new Promise((resolve, reject) => {
      this.modalService.onHidden.pipe(take(1)).subscribe((reason: string) => {
        resolve({
          produto: this.modalRef.content.produto,
          editado: this.modalRef.content.editao
        });
      });

      this.modalRef = this.modalService.show(EditarProdutoComponent, {
        animated: true,
        backdrop: true,
        ignoreBackdropClick: true,
        keyboard: true,
        class: "modal-md",
        initialState: {
          produto: produto,
        }
      });
    });
  }

  openModalNovoProduto(produto: any = null) {
    return new Promise((resolve, reject) => {
      this.modalService.onHidden.pipe(take(1)).subscribe((reason: string) => {
        resolve({
          success: this.modalRef.content.success,
        });
      });

      this.modalRef = this.modalService.show(NovoProdutoComponent, {
        animated: true,
        backdrop: true,
        ignoreBackdropClick: true,
        keyboard: true,
        class: "modal-md"
      });
    });
  }

  openModalLogs(log: number) {
    switch (log) {
      case 1:
        this.modalRef = this.modalService.show(LogsModalComponent, {
          animated: true,
          backdrop: true,
          ignoreBackdropClick: true,
          keyboard: true,
          class: "modal-md",
          initialState: {
            logType: 1
          }
        });
        break;
      case 2:
        this.modalRef = this.modalService.show(LogsModalComponent, {
          animated: true,
          backdrop: true,
          ignoreBackdropClick: true,
          keyboard: true,
          class: "modal-md",
          initialState: {
            logType: 2
          }
        });
        break;
    }
  }
}
