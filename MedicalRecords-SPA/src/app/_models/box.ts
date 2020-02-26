import { File } from "./file"

export interface Box {
  boxId: number;
  barcodeNum: number;
  department: number;
  county: number;
  files?: File[];
  from: string;
  to: string;
  description: string;
  destroyed: boolean;
  actualDestructionDate: Date;
}
