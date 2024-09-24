# PosTech.Fase1.Contatos

# Postech.Fase2.Contatos
modelo Url Prometheus
http://localhost:9090/graph?g0.expr=dotnet_total_memory_bytes&g0.tab=0&g0.display_mode=stacked&g0.show_exemplars=0&g0.range_input=15m&g1.expr=irate(process_cpu_seconds_total%5B1m%5D)&g1.tab=0&g1.display_mode=lines&g1.show_exemplars=0&g1.range_input=1h&g2.expr=rate(http_request_duration_seconds_sum%5B3m%5D)%2Frate(http_request_duration_seconds_count%5B3m%5D)&g2.tab=0&g2.display_mode=lines&g2.show_exemplars=0&g2.range_input=1m&g2.end_input=2024-09-24%2021%3A17%3A24&g2.moment_input=2024-09-24%2021%3A17%3A24