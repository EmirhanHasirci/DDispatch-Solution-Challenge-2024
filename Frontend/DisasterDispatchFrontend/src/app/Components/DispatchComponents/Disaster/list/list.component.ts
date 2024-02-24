import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DisasterServicesService } from 'src/app/Services/disaster.service';
import { WithAssignerAndCategory } from 'src/app/Models/DTOS/DisasterOperation/with-assigner-and-category';
import { SharedModule } from 'src/app/Common/Shared/shared.module';
import { Cities } from 'src/app/Common/cities';

@Component({
  selector: 'app-list',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  result: WithAssignerAndCategory[];
  constructor(private service: DisasterServicesService) {
  }
  cities: Cities=new Cities();
  getCityName(id: string): string|any {            
    return this.cities.searchCityById(id)?.name;
  }
  ngOnInit(): void {
    this.getAll();
  }
  getAll() {
    this.service.getDisasterOperationsWithCategories().subscribe(x => {
      this.result = x;
     
    })
  }
}
