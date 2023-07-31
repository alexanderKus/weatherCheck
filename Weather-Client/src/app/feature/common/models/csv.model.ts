export class Csv {
  private readonly rows: string[];

  constructor() {
    this.rows = [];
  }

  public get getRows() {
    return this.rows;
  }

  public addRow(row: string) {
    this.rows.push(row + '\n');
  }
}
