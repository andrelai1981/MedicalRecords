import { File } from "./file"
import { County } from "./county"
import { Department } from "./department"

export interface Box {
  boxId: number;
  barcodeNum: string;
  department: Department[];
  county: County[];
  files?: File[];
  from: string;
  to: string;
  description: string;
  destroyed: boolean;
}
