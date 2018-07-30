import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class AppService {

  constructor(private http: Http) { }

  getVM() {
    return this.http.get('http://dev.api:5001/api/MachineVirtuelle');
  }

}
