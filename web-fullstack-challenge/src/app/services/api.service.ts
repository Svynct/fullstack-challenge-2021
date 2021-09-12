import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class ApiService {
  baseUrl: string = 'https://localhost:44373';

  constructor() { }

  request(controller: string, method: string, param: any, queryable: boolean = false) {
    let request = this.baseUrl + controller + "/" + method;

    if (queryable) request += this.queryable(param);
    else request += (param !== "" ? "/" + param : "")

    return request;
  }

  queryable(obj: any) {
    let query = '?';
    Object.keys(obj).forEach(k => query += `${k}=${obj[k]}&`);
    return query.substring(0, query.length - 1);
  }
}
