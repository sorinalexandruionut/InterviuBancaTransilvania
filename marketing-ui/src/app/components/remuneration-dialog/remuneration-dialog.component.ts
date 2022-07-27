import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { ItemModel } from 'src/app/models/item.model';
import { ProductService } from 'src/app/services/product.service';
import { RemunerationService } from 'src/app/services/remuneration.service';
import { RetailerService } from 'src/app/services/retailer.service';
import { RemunerationEditModel } from './remuneration-edit.model';

@Component({
  selector: 'app-remuneration-dialog',
  templateUrl: './remuneration-dialog.component.html',
  styles: [
  ]
})
export class RemunerationDialogComponent implements OnInit {

  @Output() refreshData = new EventEmitter<void>();
  
  public currentRemuneration!: RemunerationEditModel;
  public dialogVisible = false;
  public saveInProgress = false;

  public yearOptions: any[] | undefined;
  public monthOptions: any[] | undefined;
  public retailerOptions: ItemModel[] = [];
  public productOptions: ItemModel[] = [];

  public formGroup: FormGroup | undefined;
  
  
  constructor(private fb: FormBuilder, private remunerationService: RemunerationService,
              private messageService: MessageService,
              private productService: ProductService,
              private retailerService: RetailerService) { }

  async ngOnInit(): Promise<void> {
    this.yearOptions = this.remunerationService.yearOptions;
    this.monthOptions = this.remunerationService.monthOptions;
    this.productOptions = await this.productService.products;
    this.retailerOptions = await this.retailerService.retailers;
  }




  public showDialog(row: any | null): void {
    this.dialogVisible = true;

    this.currentRemuneration = row ? row : new RemunerationEditModel();

    this.formGroup = this.fb.group({
      id: [this.currentRemuneration?.id],
      year: [this.currentRemuneration.year , Validators.required],
      month: [this.currentRemuneration.month, Validators.required],
      productId: [this.currentRemuneration.productId, Validators.required],
      retailerId: [this.currentRemuneration.retailerId, Validators.required],
      bonus: [this.currentRemuneration.bonus, Validators.required],
    });

    
  }

  public hideDialogue(): void {
    this.dialogVisible = false;
  }


  public async save(): Promise<void> {
    this.saveInProgress = true;
    const saveModel: RemunerationEditModel = Object.assign(this.currentRemuneration, this.formGroup?.getRawValue());

    saveModel.bonus = Number(saveModel.bonus);
    saveModel.month = Number(saveModel.month);
    saveModel.year = Number(saveModel.year);
    saveModel.productId = Number(saveModel.productId);
    saveModel.retailerId = Number(saveModel.retailerId);

    this.formGroup?.disable();

    try {
        await this.remunerationService.save(saveModel);
        this.saveInProgress = false;
        this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Discussion point saved successfully' });
        this.refreshData.emit();
        this.hideDialogue();
    }
    catch (err) {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Discussion point could not be saved!' });
        this.saveInProgress = false;
    } finally {
        this.formGroup?.enable();
    }
}

}
