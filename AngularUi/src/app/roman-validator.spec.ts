import { RomanValidator } from './roman-validator';

describe('RomanValidator', () => {
  it('should create an instance', () => {
    const directive = new RomanValidator();
    expect(directive).toBeTruthy();
  });
});
