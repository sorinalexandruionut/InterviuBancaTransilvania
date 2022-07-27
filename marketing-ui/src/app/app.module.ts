import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';



import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RemunerationListComponent } from './components/remuneration-list/remuneration-list.component';


import { TableModule } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastModule } from 'primeng/toast';
import { ProgressSpinnerModule } from 'primeng/progressspinner';

import { RemunerationDialogComponent } from './components/remuneration-dialog/remuneration-dialog.component';
import { DropdownModule } from 'primeng/dropdown';
import { InputNumberModule } from 'primeng/inputnumber';


import {MessagesModule} from 'primeng/messages';
import { ConfirmationService, MessageService } from 'primeng/api';
import { PivotRemunerationComponent } from './components/pivot-remuneration/pivot-remuneration.component';
import { StatisticsRemunerationComponent } from './components/statistics-remuneration/statistics-remuneration.component';

@NgModule({
  declarations: [
    AppComponent,
    RemunerationListComponent,
    RemunerationDialogComponent,
    PivotRemunerationComponent,
    StatisticsRemunerationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    TableModule,
    DialogModule,
    ButtonModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    DropdownModule,
    InputNumberModule,
    ToastModule,
    MessagesModule,
    ProgressSpinnerModule
  ],
  providers: [
    ConfirmationService,
    MessageService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
