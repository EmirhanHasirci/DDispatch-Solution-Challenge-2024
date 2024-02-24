import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import * as $ from "jquery";
import { DisasterServicesService } from 'src/app/Services/disaster.service';
import { DisasterCategoryDto } from 'src/app/Models/DTOS/DisasterCategory/disaster-category-dto';
import { DisasterOperationAndCity } from 'src/app/Models/DTOS/DisasterOperation/disaster-operation-and-city';
import { CreateDto } from 'src/app/Models/DTOS/DisasterOperation/create-dto';
import { Guid } from 'guid-typescript';
import { SharedModule } from 'src/app/Common/Shared/shared.module';


@Component({
  selector: 'app-index',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {
  constructor(private disasterService: DisasterServicesService) {

  }
  categories: DisasterCategoryDto[];
  getCategories() {
    this.disasterService.getDisasterCategoryDtos().subscribe(x => {
      this.categories = x;
    })
  }
  selectedCategory: string

  categoryId: string;
  selectedCities: Event[] = [];
  selectedCitiesId: string[] = [];
  postDto: CreateDto[] = [];
  postDisasterOperation() {
    if (this.selectedCitiesId !== null) {
      for (let city of this.selectedCitiesId) {
        let dto: CreateDto = new CreateDto();
        dto.AssignerId = "674142ee-3e71-4d0b-91ca-d0dd19b42885";
        dto.DisasterCategoryId = this.selectedCategory;
        dto.ProvinceId = city;
        console.log(dto);

        this.postDto.push(dto);
      }
      this.disasterService.postDisasterOperationAddRange(this.postDto);
    }
  }
  selectCategory(e: any) {
    this.selectedCategory = e.value
    console.log(this.selectedCategory);
    
  }
  ngOnInit() {
    let self = this;
    this.getCategories();

    const selectedCitiesPanel: HTMLElement | null = document.querySelector(".selectedCities");
    const cityName: HTMLElement | null = document.querySelector(".City-Name");

    $('.map path').mouseover(function (e: JQuery.MouseOverEvent) {
      if (cityName) cityName.innerHTML = "City Name: <span class='text-info fw-bolder'>" + e.target.getAttribute("title") + "</span>";

    })
      .mouseleave(function () {
        $('.info_panel').remove();
      })

      .click(function (e: JQuery.ClickEvent) {
        let text = "";
        if (selectedCitiesPanel) selectedCitiesPanel.innerHTML = "";
        e.target.classList.toggle("selectedCity");
        if (e.target.classList.contains("selectedCity")) {
          self.selectedCities.unshift(e.originalEvent!);
          self.selectedCitiesId.unshift(e.target.id.substring(e.target.id.length - 2));

        } else {

          for (let index = 0; index < self.selectedCities.length; index++) {
            if ((self.selectedCities[index].target as HTMLElement).getAttribute("id") == e.target.getAttribute("id")) {
              self.selectedCitiesId.splice(index, 1);
              self.selectedCities.splice(index, 1);
            }
            console.log(self.selectedCitiesId);

          }
        }
        for (let item of self.selectedCities) {
          text += '<li class="list-group-item">' + (item.target as HTMLElement).getAttribute("title") + '</li>';
        }
        $(text).appendTo(selectedCitiesPanel!);
      });


    /*

    $(document).on("mousemove", function (e: JQuery.MouseMoveEvent) {
      const mouseX = e.pageX; // X coordinates of mouse
      const mouseY = e.pageY; // Y coordinates of mouse      
      $('.info_panel').css({
        
        top: mouseY - 100,
        left: mouseX - ($('.info_panel').width()! /  - 20),
      });
    });
    */
  }
}
