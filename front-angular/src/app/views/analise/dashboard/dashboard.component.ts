import { Component } from '@angular/core';
import { ChartConfiguration, ChartData, ChartEvent, ChartType } from 'chart.js';
import DashboardResultModel from 'src/app/models/Results/DashboardResultModel';
import { DashBoardService } from 'src/app/services/dash-board.service';
import FilterCommandModel from '../../../models/FilterCommandModel';
import { AnaliseRiscoRelatorio } from 'src/app/models/Results/AnaliseRiscoRelatorio';
import FiltroDataDeAteCommandModel from 'src/app/models/FiltroDataDeAteCommandModel';


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


  graficoBarra: any;
  graficoPizza: any;
  graficoVelocimetro:any;

  constructor(private service: DashBoardService) { }

  ngOnInit() {
    this.buscarRelatorios();
  }

  buscarRelatorios() {
    let filterGraficos = new FiltroDataDeAteCommandModel(this.filter.dataSolicitacaoDe, this.filter.dataSolicitacaoAte);
    this.service.buscarRelatorioGeral(this.filter)
      .subscribe({
        next: (result: AnaliseRiscoRelatorio[]) => {
          this.analiseRiscoRelatorioPrincipal = result;

          this.pendentes = result.filter(ar => ar.status.toLocaleLowerCase() == "pendente").length
          this.aprovados = result.filter(ar => ar.status.toLocaleLowerCase() == "aprovado").length
          this.reprovados = result.filter(ar => ar.status.toLocaleLowerCase() == "reprovado").length
        }
      });

    this.service.buscarGraficoBarras(filterGraficos)
      .subscribe({
        next: (result: DashboardResultModel) => {
          console.log(result)
          this.graficoBarra = result;
        }
      })

    this.service.buscarGraficoLinha(filterGraficos)
      .subscribe({
        next: (result: DashboardResultModel) => {
          this.graficoVelocimetro = result;
        }
      })

    this.service.buscarGraficoPizza(filterGraficos)
      .subscribe({
        next: (result: DashboardResultModel) => {
          this.graficoPizza = result;
        }
      });
  }

}
