import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RomanNumberService } from '../roman-number.service';
import { RomanValidatorDirective } from '../roman-validator.directive';

@Component({
  selector: 'app-divide',
  standalone: true,
  imports: [FormsModule, RomanValidatorDirective],
  templateUrl: './divide.component.html'
})
export class DivideComponent {
  dividend = '';
  divisor = '';

  result: { quotient: string; remainder: string } | null = null;
  error = '';
  loading = false;

  constructor(private service: RomanNumberService) { }

  divide(): void {
    this.result = null;
    this.error = '';
    this.loading = true;

    this.service.divide(this.dividend, this.divisor).subscribe({
      next: result => {
        this.result = result;
        this.loading = false;
      },
      error: () => {
        this.error = 'Division fehlgeschlagen.';
        this.loading = false;
      }
    });
  }
}
