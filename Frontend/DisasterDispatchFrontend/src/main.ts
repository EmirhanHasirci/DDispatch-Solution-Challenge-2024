import { BrowserModule, bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { HttpClient, provideHttpClient } from "@angular/common/http"
import { importProvidersFrom } from '@angular/core';
import { CommonModule } from '@angular/common';
import {BrowserAnimationsModule} from "@angular/platform-browser/animations"
import { RouterModule } from '@angular/router';
import { routes } from './app/router';



bootstrapApplication(AppComponent,{
  providers:[
    provideHttpClient(),
    importProvidersFrom(
      BrowserModule,
      CommonModule,
      BrowserAnimationsModule,
      RouterModule.forRoot(routes),
      HttpClient
      
    ),
    {provide: "baseUrl",useValue:"https://localhost:7155/api",multi:true}
  ]
})
