import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Remuneration } from '../components/remuneration-list/remuneration.model';
import { environment } from 'src/environments/environment';
import { RemunerationEditModel } from '../components/remuneration-dialog/remuneration-edit.model';
import { StatisticsRemunerationModel } from '../components/statistics-remuneration/statistics-remuneration.model';

@Injectable({
  providedIn: 'root'
})
export class RemunerationService {
  url: string;

  constructor(private httpClient: HttpClient) {
    this.url = `${environment.apiUrl}/remuneration`;
  }

  private _yearOptions: any[];
    get yearOptions(): any[]{
        if (!this._yearOptions) {
            this._yearOptions = [{label:'2020', value:2020},{label:'2021', value:2021},{label:'2022', value:2022},{label: '2023', value: 2023}];
        }
        return this._yearOptions;
  }


  private _monthOptons: any[];
    get monthOptions(): any[]{
        if (!this._monthOptons) {
            this._monthOptons = [{label:'1', value: 1},{label:'2', value: 2},{label:'3', value: 3},{label:'4', value: 4},{label:'5', value: 5},{label:'6', value: 6}
            ,{label:'7', value: 7},{label:'8', value: 8},{label:'9', value: 9},{label:'10', value: 10},{label:'11', value: 11},{label:'12', value: 12}];

        }
        return this._monthOptons;
  }



  public getAll(): Promise<Remuneration[]> {
    return this.httpClient.get<Remuneration[]>(this.url).toPromise();
  }

  public save(remuneration: RemunerationEditModel): Promise<Remuneration> {
    return this.httpClient.post<Remuneration>(this.url +'/save', remuneration ).toPromise();
  }

  public getRemunerationsPivot(month: number, year: number): Promise<any> {
    return this.httpClient.get<any>(this.url + '/pivot', {params : {month, year} as any}).toPromise();
  }

  public getStatistics(month: number, year: number): Promise<StatisticsRemunerationModel[]> {
    return this.httpClient.get<StatisticsRemunerationModel[]>(this.url + '/statistics', {params : {month, year} as any}).toPromise();
  }
}
