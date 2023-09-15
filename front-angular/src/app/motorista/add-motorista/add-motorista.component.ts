import { Component } from '@angular/core';
import { MotoristaService } from 'src/app/services/motorista.service';

@Component({
  selector: 'app-add-motorista',
  templateUrl: './add-motorista.component.html',
  styleUrls: ['./add-motorista.component.scss']
})
export class AddMotoristaComponent {

  constructor(private _service: MotoristaService) {
  }


  testarApi(event: Event){
    event.preventDefault()

    this._service.teste().subscribe((result)=>{

      console.log(result);
    });
  }
}
