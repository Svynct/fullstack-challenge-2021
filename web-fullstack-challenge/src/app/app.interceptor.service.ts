import {
  HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse
} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { tap } from "rxjs/operators";


@Injectable()
export class AppInterceptor implements HttpInterceptor {

  constructor() { }

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {

    req = req.clone({
      headers: req.headers
        .set("Content-Type", "application/json")
        .set("Access-Control-Allow-Origin", "*")
        .set("Access-Control-Allow-Methods", "GET, POST, OPTIONS, PUT, PATCH, DELETE")
        .set("Access-Control-Allow-Headers", "Access-Control-Allow-Headers, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers")
    });

    return next.handle(req).pipe(
      tap((event: HttpEvent<any>) => {
        if (event instanceof HttpResponse) { }
      }, err => { }
      )
    );
  }
}
