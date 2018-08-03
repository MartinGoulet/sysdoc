import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

@Injectable()
export class AppService {


  constructor(private http: HttpClient) { }

  getVM() {
    return this.http.get('http://localhost:5000/api/MachineVirtuelle');
  }

  insert(vm) {
    return this.http.post('http://localhost:5000/api/MachineVirtuelle', vm);
  }

  supprimer(vm): any {
    const id = typeof vm === 'number' ? vm : vm.id;
    const url = `http://localhost:5000/api/MachineVirtuelle/${id}`;

    // const params = new HttpParams().set('Id', id);
    // const headers = new HttpHeaders().set('content-type', 'application/json');

    return this.http.delete(url);
  }

}
