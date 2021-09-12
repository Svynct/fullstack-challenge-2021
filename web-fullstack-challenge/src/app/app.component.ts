import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'web-fullstack-challenge';

  constructor(private router: Router) { }

  click(n: number) {
    switch (n) {
      case 1:
        this.router.navigate(['/'])
        break;
      case 2:
        this.router.navigate(['/servicos'])
        break;
      case 3:
        this.router.navigate(['/produtos'])
        break;
      case 4:
        this.router.navigate(['/sobre'])
        break;
    }
  }
}
