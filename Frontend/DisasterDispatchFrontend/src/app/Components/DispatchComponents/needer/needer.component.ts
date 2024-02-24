import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/Common/Shared/shared.module';
import { NeederService } from 'src/app/Services/needer.service';
import { NgForm } from '@angular/forms';
import { NeederDto } from 'src/app/Models/DTOS/Needer/needer-dto';

@Component({
  selector: 'app-needer',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './needer.component.html',
  styleUrls: ['./needer.component.scss']
})
export class NeederComponent {
  constructor(private service: NeederService) {

  }

  add(form: NgForm) {
    if (form.valid) {
      let fv=form.value;
      let dto:NeederDto=new NeederDto();
      dto.tc=fv["tc"];
      dto.name=fv["name"];
      dto.surname=fv["surname"];
      dto.phone=fv["phone"];
      dto.info=fv["info"];
      dto.id=null!;            
      this.service.postNeeder(dto);
    }
  }

}
