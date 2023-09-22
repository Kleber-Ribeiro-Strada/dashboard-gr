import { Component } from '@angular/core';
import { ChartConfiguration, ChartData, ChartEvent, ChartType } from 'chart.js';
import DashboardResultModel from 'src/app/models/Results/DashboardResultModel';
import { DashBoardService } from 'src/app/services/dash-board.service';
import FilterCommandModel from '../../../models/FilterCommandModel';
import { AnaliseRiscoRelatorio } from 'src/app/models/Results/AnaliseRiscoRelatorio';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {
  barChartOptions = {
    scaleShowVerticalLines: false,
    responsive: true,
  };
  barChartLegend = true;
  filter: FilterCommandModel = new FilterCommandModel();
  analiseRiscoRelatorioPrincipal: AnaliseRiscoRelatorio[] = [];
  pendentes = 0;
  aprovados = 0;
  reprovados = 0;

  constructor(private service: DashBoardService) { }

  ngOnInit() {
    this.buscarRelatorios();
  }

  buscarRelatorios() {
    this.service.buscarRelatorioGeral(this.filter)
      .subscribe({
        next: (result: AnaliseRiscoRelatorio[]) => {
          this.analiseRiscoRelatorioPrincipal = result;

          this.pendentes = result.filter(ar=>ar.status.toLocaleLowerCase() == "pendente").length
          this.aprovados = result.filter(ar=>ar.status.toLocaleLowerCase() == "aprovado").length
          this.reprovados = result.filter(ar=>ar.status.toLocaleLowerCase() == "reprovado").length
        }
      })
  }

  graficoBarra: DashboardResultModel = {
    labels: ['2006', '2007', '2008', '2009', '2010', '2011', '2012'],
    datasets: [
      { data: [65, 59, 80, 81, 56, 55, 40], label: 'Reprovado' },
      { data: [28, 48, 40, 19, 86, 27, 90], label: 'Aprovado' }
    ]
  }

  graficoPizza: DashboardResultModel = {
    labels: ['Aprovada', 'Reprovada', 'Aguardando Análise'],
    datasets: [
      { data: [65, 59, 80], label: 'Análises' }
    ]
  }


  graficoVelocimetro: DashboardResultModel = {
    labels: ['09:00', '09:30', '10:00', '10:30', '11:00', '11:30', '12:00', '12:30', '13:00', '13:30', '14:00'],
    datasets: [
      { data: [10, 20, 30, 40, 100, 200, 700, 800, 810, 820, 830], label: 'Quantidade de análises' },
      { data: [1, 2, 3, 4, 10, 20, 70, 80, 81, 82, 83], label: 'Aprovadas' },
      { data: [5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55], label: 'Reprovadas' }
    ]
  };
}
