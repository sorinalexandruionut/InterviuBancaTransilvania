import { Component, OnInit } from '@angular/core';
import { ItemModel } from 'src/app/models/item.model';
import { ProductService } from 'src/app/services/product.service';
import { RemunerationService } from 'src/app/services/remuneration.service';
import { RetailerService } from 'src/app/services/retailer.service';

@Component({
  selector: 'app-pivot-remuneration',
  templateUrl: './pivot-remuneration.component.html',
  styleUrls: ['./pivot-remuneration.component.css']
})
export class PivotRemunerationComponent implements OnInit {
  public yearOptions: any[];
  public monthOptions: any[];



  public retailers: ItemModel[] = [];
  public products: ItemModel[] = [];


  public month: number = 1;
  public year: number = 2021;

  public pivotResults: any;

  constructor(private remunerationService: RemunerationService,
    private productService: ProductService,
    private retailerService: RetailerService) { }


  async ngOnInit(): Promise<void> {
    this.yearOptions = this.remunerationService.yearOptions;
    this.monthOptions = this.remunerationService.monthOptions;

    this.products = await this.productService.products;
    this.retailers = await this.retailerService.retailers;

    this.getData();
  }

  public async ddlChange(event: any): Promise<void> {
    await this.getData();
  }


  public async getData() {
    this.pivotResults = await this.remunerationService.getRemunerationsPivot(this.month, this.year);
  }
}
