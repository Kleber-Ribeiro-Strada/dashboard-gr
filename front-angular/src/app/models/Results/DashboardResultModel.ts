export default class DashboardResultModel {
  labels:   string[];
  datasets: Dataset[];
}

export class Dataset {
  data:  number[];
  label: string;
}
