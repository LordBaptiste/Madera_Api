using Madera.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Madera.Api
{
    public class DatabaseInitializer
    {
        private MaderaContext _context {get;set;}

        public DatabaseInitializer(MaderaContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (!_context.Client.Any())
            {
                var clients = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText("Seed" + Path.DirectorySeparatorChar + "Client.json"));
                _context.AddRange(clients);
                await _context.SaveChangesAsync();
            }

            if (!_context.FonctionUtilisateur.Any())
            {
                var fonction = JsonConvert.DeserializeObject<List<FonctionUtilisateur>>(File.ReadAllText("Seed" + Path.DirectorySeparatorChar + "UserFonction.json"));
                _context.AddRange(fonction);
                await _context.SaveChangesAsync();
            }

            if (!_context.Utilisateur.Any())
            {
                var user = JsonConvert.DeserializeObject<List<Utilisateur>>(File.ReadAllText("Seed" + Path.DirectorySeparatorChar + "User.json"));
                _context.AddRange(user);
                await _context.SaveChangesAsync();
            }

            if (!_context.EtatDevis.Any())
            {
                var etats = JsonConvert.DeserializeObject<List<EtatDevis>>(File.ReadAllText("Seed" + Path.DirectorySeparatorChar + "EtatDevis.json"));
                _context.AddRange(etats);
                await _context.SaveChangesAsync();
            }

            if (!_context.Projet.Any())
            {
                var projet = JsonConvert.DeserializeObject<List<Projet>>(File.ReadAllText("Seed" + Path.DirectorySeparatorChar + "Projet.json"));
                _context.AddRange(projet);
                await _context.SaveChangesAsync();
            }

            if (!_context.Devis.Any())
            {
                var devis = JsonConvert.DeserializeObject<List<Devis>>(File.ReadAllText("Seed" + Path.DirectorySeparatorChar + "Devis.json"));
                _context.AddRange(devis);
                await _context.SaveChangesAsync();
            }
        }
    }
}
