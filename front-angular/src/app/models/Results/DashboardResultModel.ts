export default class DashboardResultModel {
  type: string;
  labels: string[] = [];
  datasets: Dataset[] = [];
}

export class Dataset {
  data: any[] = [];
  label: string;
}
