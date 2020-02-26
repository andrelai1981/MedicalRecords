export interface File {
  fileId: number;
  clientId: number;
  clientName: string;
  description: string;
  destroyed: boolean;
  boxId: number;
  barcodeNum: number;
  anticipatedDestructionDate: Date;
  actualDestructionDate: Date;
}
