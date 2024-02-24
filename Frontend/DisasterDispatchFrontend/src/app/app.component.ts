import { Component } from '@angular/core';
import { SharedModule } from './Common/Shared/shared.module';

@Component({
  selector: 'app-root',
  standalone:true,
  template:`<router-outlet></router-outlet>`,
  imports:[SharedModule]
})
export class AppComponent {
  title = 'DisasterDispatchFrontend';
}
