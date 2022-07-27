import { Component, OnInit, ViewChild } from '@angular/core';
import { ItemModel } from 'src/app/models/item.model';
import { ProductService } from 'src/app/services/product.service';
import { RemunerationService } from 'src/app/services/remuneration.service';
import { RetailerService } from 'src/app/services/retailer.service';
import { RemunerationDialogComponent } from '../remuneration-dialog/remuneration-dialog.component';
import { RemunerationEditModel } from '../remuneration-dialog/remuneration-edit.model';
import { Remuneration } from './remuneration.model';

@Component({
  selector: 'app-remuneration-list',
  templateUrl: './remuneration-list.component.html',
  styleUrls: ['./remuneration-list.component.css']
})
export class RemunerationListComponent implements OnInit {

  @ViewChild('d', { static: false })
  dialog!: RemunerationDialogComponent;


  public month: number = 1;
  public year: number = 2021;

  public remunerations: Remuneration[] = [];

  public pivotResults: any;

  constructor(private remunerationService: RemunerationService,
              private productService: ProductService,
              private retailerService: RetailerService) { }


  async ngOnInit(): Promise<void> {
    await this.getData();
    
  }

  public async getData(): Promise<void> 
  {
    this.remunerations = await this.remunerationService.getAll();
  }




  public showDialogue(row: any): void {
    this.dialog.showDialog(row);
  }

}
