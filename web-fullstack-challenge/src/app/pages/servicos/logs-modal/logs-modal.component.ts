import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { LogService } from 'src/app/services/log.service';

@Component({
  selector: 'app-logs-modal',
  templateUrl: './logs-modal.component.html',
  styleUrls: ['./logs-modal.component.css']
})
export class LogsModalComponent implements OnInit {

  logType: number;
  logs: any[];
  page: number = 1;

  constructor(private service: LogService, public bsModalRef: BsModalRef) { }

  ngOnInit() {
    switch (this.logType) {
      case 1:
        this.getSyncLogs();
        break;
      case 2:
        this.getDeleteLogs();
        break;
    }
  }

  getSyncLogs() {
    this.service.getSyncLogs().subscribe((res: any) => {
      if (res) {
        this.logs = res;
      }
    })
  }

  getDeleteLogs() {
    this.service.getDeleteLogs().subscribe((res: any) => {
      if (res) {
        this.logs = res;
      }
    })
  }
}
