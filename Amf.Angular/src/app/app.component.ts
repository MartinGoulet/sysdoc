import { Component, OnInit } from '@angular/core';
import { environment } from '../environments/environment';
import { AppService } from './app.service';
import { IMachineVirtuelle } from './app.modele';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'app';
  production = environment.production;
  vm: IMachineVirtuelle[] = null;

  constructor(private service: AppService) { }

  ngOnInit(): void {
    this.afficherListeVM();
  }

  ajouter(): void {
    this.service.insert({ 'nom': 'Ma machine Virtuelle' }).subscribe(x => {
      this.afficherListeVM();
    });
  }

  supprimer(vm): void {
    this.service.supprimer(vm).subscribe(x => {
      this.afficherListeVM();
    });
  }

  afficherListeVM(): void {
    this.service.getVM().subscribe((vm: IMachineVirtuelle[]) => {
      this.vm = vm.sort((a, b) => a.id - b.id);
    });
  }

}
