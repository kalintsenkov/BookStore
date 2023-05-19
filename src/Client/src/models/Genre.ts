import { Enumeration } from './common/Enumeration';

export class Genre extends Enumeration<Genre>() {
  static Horror = new Genre(1, 'Horror');
  static Fantasy = new Genre(2, 'Fantasy');
  static Mystery = new Genre(3, 'Mystery');
  static Romance = new Genre(4, 'Romance');
  static History = new Genre(5, 'History');
  static Biography = new Genre(6, 'Biography');

  static _ = Genre.closeEnum();

  name: string;
  label: string;
  value: number;

  constructor(value: number, name: string) {
    super();

    this.value = value;
    this.name = name;
    this.label = name;
  }
}