import { Component, OnInit } from '@angular/core';
import { environment } from '../environments/environment';
import { AppService } from './app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  
  title = 'app';
  production = environment.production;
  vm: any;

  constructor(private service: AppService) {}

  ngOnInit(): void {
    this.service.getVM().subscribe(vm => this.vm = vm);
  }

}
