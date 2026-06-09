using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using DIEFER.BE;
using DIEFER.DAL;
using DIEFER.Servicios;
// PrintDocument es de System.Drawing — no de System.Windows.Forms. El PrintDialog lo maneja el UI.

namespace DIEFER.BLL
{
    // Lógica de negocio para registro y consulta de eventos de la bitácora DIEFER.
    public class EventoBLL_593CM
    {
        private readonly IEventoDAL_593CM _eventoDAL_593CM;
        private readonly IUsuario_593CM   _usuarioDAL_593CM;

        public EventoBLL_593CM() : this(new EventoDAL_593CM(), new UsuarioDAL_593CM()) { }

        public EventoBLL_593CM(IEventoDAL_593CM eventoDAL, IUsuario_593CM usuarioDAL)
        {
            _eventoDAL_593CM  = eventoDAL;
            _usuarioDAL_593CM = usuarioDAL;
        }

        // Punto único de registro — invocado por cada operación que genera un evento
        public void Registrar_593CM(string login, string modulo, string evento, int criticidad)
        {
            var e = new Eventos_593CM
            {
                Login_593CM      = login,
                Fecha_593CM      = DateTime.Now,
                Hora_593CM       = DateTime.Now,
                Modulo_593CM     = modulo,
                Evento_593CM     = evento,
                Criticidad_593CM = criticidad,
            };
            _eventoDAL_593CM.Insertar_593CM(e);
        }

        public List<Eventos_593CM> GetEventos_593CM(DateTime? fechaIni, DateTime? fechaFin,
                                                     string login, string modulo,
                                                     string evento, int? criticidad)
        {
            return _eventoDAL_593CM.GetByFiltro_593CM(fechaIni, fechaFin, login, modulo, evento, criticidad);
        }

        public (string Nombre, string Apellido) GetNombreApellido_593CM(string login)
        {
            return _usuarioDAL_593CM.BuscarNombreApellidoPorLogin_593CM(login);
        }

        // Prepara el PrintDocument para imprimir — el PrintDialog lo muestra el UI (FormBitacora_593CM)
        public PrintDocument CrearDocumentoDePrint_593CM(List<Eventos_593CM> lista,
                                                          string titulo = "Bitácora de Eventos — DIEFER")
        {
            int fila = 0;
            var doc  = new PrintDocument { DocumentName = titulo };

            doc.PrintPage += (sender, e) =>
            {
                var font      = new Font("Arial", 8);
                var fontTitle = new Font("Arial", 10, FontStyle.Bold);
                var fontHead  = new Font("Arial", 8, FontStyle.Bold);
                float y       = e.MarginBounds.Top;
                float x       = e.MarginBounds.Left;
                int[] anchos  = { 100, 70, 50, 80, 160, 70 };
                string[] cols = { "Login", "Fecha", "Hora", "Módulo", "Evento", "Crit." };

                e.Graphics.DrawString(titulo, fontTitle, Brushes.Black, x, y);
                y += fontTitle.GetHeight(e.Graphics) + 4;

                float xCol = x;
                for (int i = 0; i < cols.Length; i++)
                {
                    e.Graphics.DrawString(cols[i], fontHead, Brushes.Black, xCol, y);
                    xCol += anchos[i];
                }
                y += fontHead.GetHeight(e.Graphics) + 2;
                e.Graphics.DrawLine(Pens.Black, x, y, e.MarginBounds.Right, y);
                y += 2;

                while (fila < lista.Count && y < e.MarginBounds.Bottom - 20)
                {
                    var ev = lista[fila];
                    xCol = x;
                    string[] vals =
                    {
                        ev.Login_593CM,
                        ev.Fecha_593CM.ToString("dd/MM/yyyy"),
                        ev.Hora_593CM.ToString("HH:mm:ss"),
                        ev.Modulo_593CM,
                        ev.Evento_593CM,
                        ev.Criticidad_593CM.ToString()
                    };
                    for (int i = 0; i < vals.Length; i++)
                    {
                        e.Graphics.DrawString(vals[i], font, Brushes.Black,
                            new RectangleF(xCol, y, anchos[i] - 2, font.GetHeight(e.Graphics) + 2));
                        xCol += anchos[i];
                    }
                    y += font.GetHeight(e.Graphics) + 1;
                    fila++;
                }

                e.HasMorePages = fila < lista.Count;
                font.Dispose(); fontTitle.Dispose(); fontHead.Dispose();
            };

            return doc;
        }
    }
}
