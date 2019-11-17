import { EventEmitter, Directive, ElementRef, Output, OnInit } from '@angular/core';

@Directive({
    selector: '[appDatepicker]'
})
export class DatepickerDirective implements OnInit {
// tslint:disable-next-line: no-output-native
    @Output() public dateChange = new EventEmitter();

    constructor(private elementRef: ElementRef) {}

    public ngOnInit() {
        $(this.elementRef.nativeElement).datepicker({
            dateFormat: 'mm/dd/yyyy',
            changeYear: true,
            yearRange: '-100:+0',
            onSelect: (dateText) => {
                this.dateChange.emit(dateText);
            }
        });
    }
}
