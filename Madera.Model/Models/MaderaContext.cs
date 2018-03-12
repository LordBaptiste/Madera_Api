using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Madera.Model.Models
{
    public partial class MaderaContext : DbContext
    {
        public MaderaContext(DbContextOptions<MaderaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bloc> Bloc { get; set; }
        public virtual DbSet<Caracteristique> Caracteristique { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Composant> Composant { get; set; }
        public virtual DbSet<ComposantCaracteristique> ComposantCaracteristique { get; set; }
        public virtual DbSet<ComposantGenerique> ComposantGenerique { get; set; }
        public virtual DbSet<CritereFinition> CritereFinition { get; set; }
        public virtual DbSet<CritereQualite> CritereQualite { get; set; }
        public virtual DbSet<Devis> Devis { get; set; }
        public virtual DbSet<EtatDevis> EtatDevis { get; set; }
        public virtual DbSet<FamilleComposant> FamilleComposant { get; set; }
        public virtual DbSet<FamilleModule> FamilleModule { get; set; }
        public virtual DbSet<FinitionGamme> FinitionGamme { get; set; }
        public virtual DbSet<FonctionUtilisateur> FonctionUtilisateur { get; set; }
        public virtual DbSet<Fournisseur> Fournisseur { get; set; }
        public virtual DbSet<Gamme> Gamme { get; set; }
        public virtual DbSet<GammeFinition> GammeFinition { get; set; }
        public virtual DbSet<Maison> Maison { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<ModuleCaracteristique> ModuleCaracteristique { get; set; }
        public virtual DbSet<ModuleComposant> ModuleComposant { get; set; }
        public virtual DbSet<ModuleComposantGenerique> ModuleComposantGenerique { get; set; }
        public virtual DbSet<Projet> Projet { get; set; }
        public virtual DbSet<Utilisateur> Utilisateur { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\robac\source\repos\Madera_Api\Madera.BddTest\Madera_Bdd.mdf;Integrated Security=True;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bloc>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdMaison).HasColumnName("id_Maison");

                entity.Property(e => e.IdModule).HasColumnName("id_Module");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMaisonNavigation)
                    .WithMany(p => p.Bloc)
                    .HasForeignKey(d => d.IdMaison)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bloc_id_Maison");

                entity.HasOne(d => d.IdModuleNavigation)
                    .WithMany(p => p.Bloc)
                    .HasForeignKey(d => d.IdModule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bloc_id_Module");
            });

            modelBuilder.Entity<Caracteristique>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Unite)
                    .IsRequired()
                    .HasColumnName("unite")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adresse)
                    .IsRequired()
                    .HasColumnName("adresse")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodePostal)
                    .IsRequired()
                    .HasColumnName("code_postal")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasColumnName("prenom")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone).HasColumnName("telephone");

                entity.Property(e => e.Ville)
                    .IsRequired()
                    .HasColumnName("ville")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Composant>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.IdCaracteristique).HasColumnName("id_Caracteristique");

                entity.Property(e => e.IdCritereQualite).HasColumnName("id_Critere_Qualite");

                entity.Property(e => e.IdFamilleComposant).HasColumnName("id_Famille_Composant");

                entity.Property(e => e.IdFournisseur).HasColumnName("id_Fournisseur");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrixHt).HasColumnName("prix_ht");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasColumnName("reference")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCaracteristiqueNavigation)
                    .WithMany(p => p.Composant)
                    .HasForeignKey(d => d.IdCaracteristique)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Composant_id_Caracteristique");

                entity.HasOne(d => d.IdCritereQualiteNavigation)
                    .WithMany(p => p.Composant)
                    .HasForeignKey(d => d.IdCritereQualite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Composant_id_Critere_Qualite");

                entity.HasOne(d => d.IdFamilleComposantNavigation)
                    .WithMany(p => p.Composant)
                    .HasForeignKey(d => d.IdFamilleComposant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Composant_id_Famille_Composant");

                entity.HasOne(d => d.IdFournisseurNavigation)
                    .WithMany(p => p.Composant)
                    .HasForeignKey(d => d.IdFournisseur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Composant_id_Fournisseur");
            });

            modelBuilder.Entity<ComposantCaracteristique>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdCaracteristique })
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Composant_Caracteristique");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCaracteristique).HasColumnName("id_Caracteristique");

                entity.Property(e => e.Valeur).HasColumnName("valeur");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.ComposantCaracteristique)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Composant_Caracteristique_id");

                entity.HasOne(d => d.IdCaracteristiqueNavigation)
                    .WithMany(p => p.ComposantCaracteristique)
                    .HasForeignKey(d => d.IdCaracteristique)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Composant_Caracteristique_id_Caracteristique");
            });

            modelBuilder.Entity<ComposantGenerique>(entity =>
            {
                entity.ToTable("Composant_Generique");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.IdFamilleComposant).HasColumnName("id_Famille_Composant");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasColumnName("reference")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFamilleComposantNavigation)
                    .WithMany(p => p.ComposantGenerique)
                    .HasForeignKey(d => d.IdFamilleComposant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Composant_Generique_id_Famille_Composant");
            });

            modelBuilder.Entity<CritereFinition>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdCritereQualite })
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Critere_Finition");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCritereQualite).HasColumnName("id_Critere_Qualite");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.CritereFinition)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Critere_Finition_id");

                entity.HasOne(d => d.IdCritereQualiteNavigation)
                    .WithMany(p => p.CritereFinition)
                    .HasForeignKey(d => d.IdCritereQualite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Critere_Finition_id_Critere_Qualite");
            });

            modelBuilder.Entity<CritereQualite>(entity =>
            {
                entity.ToTable("Critere_Qualite");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdFamilleComposant).HasColumnName("id_Famille_Composant");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFamilleComposantNavigation)
                    .WithMany(p => p.CritereQualite)
                    .HasForeignKey(d => d.IdFamilleComposant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Critere_Qualite_id_Famille_Composant");
            });

            modelBuilder.Entity<Devis>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdEtatDevis).HasColumnName("id_Etat_Devis");

                entity.Property(e => e.IdMaison).HasColumnName("id_Maison");

                entity.Property(e => e.IdProjet).HasColumnName("id_Projet");

                entity.Property(e => e.Prix).HasColumnName("prix");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasColumnName("reference")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEtatDevisNavigation)
                    .WithMany(p => p.Devis)
                    .HasForeignKey(d => d.IdEtatDevis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Devis_id_Etat_Devis");

                entity.HasOne(d => d.IdMaisonNavigation)
                    .WithMany(p => p.Devis)
                    .HasForeignKey(d => d.IdMaison)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Devis_id_Maison");

                entity.HasOne(d => d.IdProjetNavigation)
                    .WithMany(p => p.Devis)
                    .HasForeignKey(d => d.IdProjet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Devis_id_Projet");
            });

            modelBuilder.Entity<EtatDevis>(entity =>
            {
                entity.ToTable("Etat_Devis");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FamilleComposant>(entity =>
            {
                entity.ToTable("Famille_Composant");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FamilleModule>(entity =>
            {
                entity.ToTable("Famille_Module");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FinitionGamme>(entity =>
            {
                entity.ToTable("Finition_Gamme");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdFamilleComposant).HasColumnName("id_Famille_Composant");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasColumnName("reference")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFamilleComposantNavigation)
                    .WithMany(p => p.FinitionGamme)
                    .HasForeignKey(d => d.IdFamilleComposant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Finition_Gamme_id_Famille_Composant");
            });

            modelBuilder.Entity<FonctionUtilisateur>(entity =>
            {
                entity.ToTable("Fonction_Utilisateur");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fournisseur>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adresse)
                    .IsRequired()
                    .HasColumnName("adresse")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodePostal)
                    .IsRequired()
                    .HasColumnName("code_postal")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasColumnName("reference")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone).HasColumnName("telephone");

                entity.Property(e => e.Ville)
                    .IsRequired()
                    .HasColumnName("ville")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Gamme>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Marge).HasColumnName("marge");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GammeFinition>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdFinitionGamme })
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Gamme_Finition");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdFinitionGamme).HasColumnName("id_Finition_Gamme");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.GammeFinition)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gamme_Finition_id");

                entity.HasOne(d => d.IdFinitionGammeNavigation)
                    .WithMany(p => p.GammeFinition)
                    .HasForeignKey(d => d.IdFinitionGamme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gamme_Finition_id_Finition_Gamme");
            });

            modelBuilder.Entity<Maison>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdDevis).HasColumnName("id_Devis");

                entity.Property(e => e.IdGamme).HasColumnName("id_Gamme");

                entity.HasOne(d => d.IdDevisNavigation)
                    .WithMany(p => p.Maison)
                    .HasForeignKey(d => d.IdDevis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Maison_id_Devis");

                entity.HasOne(d => d.IdGammeNavigation)
                    .WithMany(p => p.Maison)
                    .HasForeignKey(d => d.IdGamme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Maison_id_Gamme");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCaracteristique).HasColumnName("id_Caracteristique");

                entity.Property(e => e.IdFamilleModule).HasColumnName("id_Famille_Module");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasColumnName("reference")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCaracteristiqueNavigation)
                    .WithMany(p => p.Module)
                    .HasForeignKey(d => d.IdCaracteristique)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Module_id_Caracteristique");

                entity.HasOne(d => d.IdFamilleModuleNavigation)
                    .WithMany(p => p.Module)
                    .HasForeignKey(d => d.IdFamilleModule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Module_id_Famille_Module");
            });

            modelBuilder.Entity<ModuleCaracteristique>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdCaracteristique })
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Module_Caracteristique");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCaracteristique).HasColumnName("id_Caracteristique");

                entity.Property(e => e.Valeur).HasColumnName("valeur");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.ModuleCaracteristique)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Module_Caracteristique_id");

                entity.HasOne(d => d.IdCaracteristiqueNavigation)
                    .WithMany(p => p.ModuleCaracteristique)
                    .HasForeignKey(d => d.IdCaracteristique)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Module_Caracteristique_id_Caracteristique");
            });

            modelBuilder.Entity<ModuleComposant>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdComposant })
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Module_Composant");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdComposant).HasColumnName("id_Composant");

                entity.Property(e => e.Quantite).HasColumnName("quantite");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.ModuleComposant)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Module_Composant_id");

                entity.HasOne(d => d.IdComposantNavigation)
                    .WithMany(p => p.ModuleComposant)
                    .HasForeignKey(d => d.IdComposant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Module_Composant_id_Composant");
            });

            modelBuilder.Entity<ModuleComposantGenerique>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdComposantGenerique })
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Module_Composant_Generique");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdComposantGenerique).HasColumnName("id_Composant_Generique");

                entity.Property(e => e.Quantite).HasColumnName("quantite");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.ModuleComposantGenerique)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Module_Composant_Generique_id");

                entity.HasOne(d => d.IdComposantGeneriqueNavigation)
                    .WithMany(p => p.ModuleComposantGenerique)
                    .HasForeignKey(d => d.IdComposantGenerique)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Module_Composant_Generique_id_Composant_Generique");
            });

            modelBuilder.Entity<Projet>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreation)
                    .HasColumnName("date_creation")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdClient).HasColumnName("id_Client");

                entity.Property(e => e.IdUtilisateur).HasColumnName("id_Utilisateur");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasColumnName("reference")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Projet)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projet_id_Client");

                entity.HasOne(d => d.IdUtilisateurNavigation)
                    .WithMany(p => p.Projet)
                    .HasForeignKey(d => d.IdUtilisateur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projet_id_Utilisateur");
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasIndex(e => e.Mail)
                    .HasName("UQ__Utilisat__7A2129049F7ADE6B")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdFonctionUtilisateur).HasColumnName("id_Fonction_Utilisateur");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasColumnName("mail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFonctionUtilisateurNavigation)
                    .WithMany(p => p.Utilisateur)
                    .HasForeignKey(d => d.IdFonctionUtilisateur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Utilisateur_id_Fonction_Utilisateur");
            });
        }
    }
}
