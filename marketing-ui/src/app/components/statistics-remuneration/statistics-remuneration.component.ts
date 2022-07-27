import { Component, OnInit } from '@angular/core';
import { RemunerationService } from 'src/app/services/remuneration.service';
import { StatisticsRemunerationModel } from './statistics-remuneration.model';

@Component({
  selector: 'app-statistics-remuneration',
  templateUrl: './statistics-remuneration.component.html',
  styles: [
  ]
})
export class StatisticsRemunerationComponent implements OnInit {

  public yearOptions: any[];
  public monthOptions: any[];


  public month: number = 1;
  public year: number = 2021;

  public statistics: StatisticsRemunerationModel[] = [];

  constructor(private remunerationService: RemunerationService) { }


  async ngOnInit(): Promise<void> {
    this.yearOptions = this.remunerationService.yearOptions;
    this.monthOptions = this.remunerationService.monthOptions;
    await this.getData();
  }

  public async ddlChange(event: any): Promise<void> {
    await this.getData();
  }


  public async getData():  Promise<void>
  {
    this.statistics = await this.remunerationService.getStatistics(this.month, this.year);
  }


}
