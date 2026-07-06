using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace DIEFER.Servicios
{
    // Servicio singleton (Subject del Observer) que administra el idioma activo.
    // Carga los idiomas desde archivos JSON en la carpeta idiomas/ junto al ejecutable.
    public sealed class IdiomaService_593CM
    {
        private static IdiomaService_593CM _instancia;
        private static readonly object _lock = new object();

        private readonly List<IIdiomaObserver_593CM> _observers = new List<IIdiomaObserver_593CM>();
        private readonly object _observersLock = new object();
        private string _codigoActual = "es";

        // codigo → { nombre, textos{clave→valor} }
        private readonly Dictionary<string, IdiomaInfo_593CM> _idiomas =
            new Dictionary<string, IdiomaInfo_593CM>(StringComparer.OrdinalIgnoreCase);

        private IdiomaService_593CM() { }

        public static IdiomaService_593CM GetInstancia_593CM()
        {
            if (_instancia == null)
                lock (_lock)
                    if (_instancia == null)
                        _instancia = new IdiomaService_593CM();
            return _instancia;
        }

        // ── Carga ────────────────────────────────────────────────────────────────────

        // Carga todos los JSON de la carpeta idiomas/ (llamar una sola vez al iniciar).
        public void CargarIdiomas_593CM(string directorioIdiomas)
        {
            if (!Directory.Exists(directorioIdiomas)) return;

            var serializer = new JavaScriptSerializer();
            foreach (var archivo in Directory.GetFiles(directorioIdiomas, "*.json"))
            {
                try
                {
                    var json = File.ReadAllText(archivo, System.Text.Encoding.UTF8);
                    var dict = serializer.Deserialize<Dictionary<string, object>>(json);

                    string codigo = dict["codigo"]?.ToString() ?? Path.GetFileNameWithoutExtension(archivo);
                    string nombre = dict["nombre"]?.ToString() ?? codigo;
                    var textosObj = dict["textos"] as Dictionary<string, object>;

                    var textos = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    if (textosObj != null)
                        foreach (var kv in textosObj)
                            textos[kv.Key] = kv.Value?.ToString() ?? string.Empty;

                    _idiomas[codigo] = new IdiomaInfo_593CM { Nombre = nombre, Textos = textos };
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"[IdiomaService] Error cargando {archivo}: {ex.Message}");
                }
            }
        }

        // ── Consultas ────────────────────────────────────────────────────────────────

        public string CodigoActual_593CM => _codigoActual;

        public IReadOnlyList<KeyValuePair<string, string>> IdiomasDisponibles_593CM()
        {
            var lista = new List<KeyValuePair<string, string>>();
            foreach (var kv in _idiomas)
                lista.Add(new KeyValuePair<string, string>(kv.Key, kv.Value.Nombre));
            return lista;
        }

        public string ObtenerTexto_593CM(string clave, string valorDefecto = "")
        {
            if (_idiomas.TryGetValue(_codigoActual, out var info) &&
                info.Textos.TryGetValue(clave, out var texto))
                return texto;
            return valorDefecto;
        }

        // ── Observer ─────────────────────────────────────────────────────────────────

        public void Suscribir_593CM(IIdiomaObserver_593CM observer)
        {
            if (observer == null) return;

            lock (_observersLock)
            {
                if (!_observers.Contains(observer))
                    _observers.Add(observer);
            }

            // Importante:
            // al suscribirse, el observer recibe inmediatamente el idioma actual.
            // Esto corrige el caso en que el idioma fue cambiado antes de que
            // el formulario se suscriba, como ocurre después del login.
            if (_idiomas.TryGetValue(_codigoActual, out var info))
                observer.OnIdiomaChanged_593CM(_codigoActual, info.Textos);
        }

        public void Desuscribir_593CM(IIdiomaObserver_593CM observer)
        {
            lock (_observersLock)
                _observers.Remove(observer);
        }

        // Cambia el idioma activo y notifica a todos los observers.
        public void CambiarIdioma_593CM(string codigo)
        {
            if (!_idiomas.ContainsKey(codigo)) return;
            _codigoActual = codigo;
            NotificarObservers_593CM();
        }

        private void NotificarObservers_593CM()
        {
            if (!_idiomas.TryGetValue(_codigoActual, out var info)) return;
            var textos = info.Textos;
            IIdiomaObserver_593CM[] snapshot;
            lock (_observersLock)
                snapshot = _observers.ToArray();
            foreach (var obs in snapshot)
                obs.OnIdiomaChanged_593CM(_codigoActual, textos);
        }
    }

    internal sealed class IdiomaInfo_593CM
    {
        public string Nombre { get; set; }
        public Dictionary<string, string> Textos { get; set; }
    }
}
