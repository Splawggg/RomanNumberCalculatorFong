import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RomanNumberService } from '../roman-number.service';
import { RomanValidatorDirective } from '../roman-validator.directive';

@Component({
  selector: 'app-add',
  standalone: true,
  imports: [FormsModule, RomanValidatorDirective],
  templateUrl: './add.component.html'
})
export class AddComponent {
  a = '';
  b = '';
  result: string | null = null;
  error = '';
  loading = false;

  constructor(private service: RomanNumberService) {}

  add(): void {
    this.result = null;
    this.error = '';
    this.loading = true;

    this.service.add(this.a, this.b).subscribe({
      next: result => {
        this.result = result;
        this.loading = false;
      },
      error: () => {
        this.error = 'Berechnung fehlgeschlagen.';
        this.loading = false;
      }
    });
  }
}
