import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {StepsService} from "../steps.service";

@Component({
  selector: 'app-add-edit',
  templateUrl: './add-edit.component.html',
  styleUrls: ['./add-edit.component.css']
})
export class AddEditComponent implements OnInit {
  @Input('selectedItem') selectedItem: any;
  @Output('onSave') onSave: EventEmitter<any> = new EventEmitter<any>();

  title = '';
  description = '';

  constructor(private stepsService: StepsService) {
  }

  ngOnInit() {
    this.title = this.selectedItem.title;
    this.description = this.selectedItem.description;
  }

  save() {
    this.onSave.emit({id: this.selectedItem.id, title: this.title, description: this.description});
  }
}
