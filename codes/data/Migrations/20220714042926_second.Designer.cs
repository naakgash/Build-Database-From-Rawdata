﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using data;

#nullable disable

namespace data.Migrations
{
    [DbContext(typeof(IMDBContext))]
    [Migration("20220714042926_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CollectionMovie", b =>
                {
                    b.Property<int>("CollectionsId")
                        .HasColumnType("integer");

                    b.Property<int>("MoviesId")
                        .HasColumnType("integer");

                    b.HasKey("CollectionsId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("CollectionMovie");
                });

            modelBuilder.Entity("CountryMovie", b =>
                {
                    b.Property<int>("CountriesId")
                        .HasColumnType("integer");

                    b.Property<int>("MoviesId")
                        .HasColumnType("integer");

                    b.HasKey("CountriesId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("CountryMovie");
                });

            modelBuilder.Entity("data.BaseModels.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BackdropPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DataId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PosterPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("data.BaseModels.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("data.BaseModels.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DataId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("data.BaseModels.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("data.BaseModels.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Adult")
                        .HasColumnType("boolean");

                    b.Property<long>("Budget")
                        .HasColumnType("bigint");

                    b.Property<long>("DataId")
                        .HasColumnType("bigint");

                    b.Property<string>("Homepage")
                        .HasColumnType("text");

                    b.Property<string>("ImdbId")
                        .HasColumnType("text");

                    b.Property<string>("OriginalLanguage")
                        .HasColumnType("text");

                    b.Property<string>("OriginalTitle")
                        .HasColumnType("text");

                    b.Property<string>("Overview")
                        .HasColumnType("text");

                    b.Property<double?>("Popularity")
                        .HasColumnType("double precision");

                    b.Property<string>("PosterPath")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("Revenue")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("Runtime")
                        .HasColumnType("numeric");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("Tagline")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("Video")
                        .HasColumnType("text");

                    b.Property<decimal?>("VoteAverage")
                        .HasColumnType("numeric");

                    b.Property<int?>("VoteCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("data.Rawdatum", b =>
                {
                    b.Property<bool>("Adult")
                        .HasColumnType("boolean")
                        .HasColumnName("adult");

                    b.Property<string>("BelongsToCollection")
                        .HasMaxLength(184)
                        .HasColumnType("character varying(184)")
                        .HasColumnName("belongs_to_collection");

                    b.Property<long>("Budget")
                        .HasColumnType("bigint")
                        .HasColumnName("budget");

                    b.Property<string>("Genres")
                        .IsRequired()
                        .HasMaxLength(264)
                        .HasColumnType("character varying(264)")
                        .HasColumnName("genres");

                    b.Property<string>("Homepage")
                        .HasMaxLength(242)
                        .HasColumnType("character varying(242)")
                        .HasColumnName("homepage");

                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("ImdbId")
                        .HasMaxLength(9)
                        .HasColumnType("character varying(9)")
                        .HasColumnName("imdb_id");

                    b.Property<string>("OriginalLanguage")
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("original_language");

                    b.Property<string>("OriginalTitle")
                        .IsRequired()
                        .HasMaxLength(109)
                        .HasColumnType("character varying(109)")
                        .HasColumnName("original_title");

                    b.Property<string>("Overview")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("overview");

                    b.Property<double?>("Popularity")
                        .HasColumnType("double precision")
                        .HasColumnName("popularity");

                    b.Property<string>("PosterPath")
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)")
                        .HasColumnName("poster_path");

                    b.Property<string>("ProductionCompanies")
                        .HasMaxLength(1252)
                        .HasColumnType("character varying(1252)")
                        .HasColumnName("production_companies");

                    b.Property<string>("ProductionCountries")
                        .HasMaxLength(1039)
                        .HasColumnType("character varying(1039)")
                        .HasColumnName("production_countries");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("release_date");

                    b.Property<long?>("Revenue")
                        .HasColumnType("bigint")
                        .HasColumnName("revenue");

                    b.Property<decimal?>("Runtime")
                        .HasPrecision(6, 1)
                        .HasColumnType("numeric(6,1)")
                        .HasColumnName("runtime");

                    b.Property<string>("SpokenLanguages")
                        .HasMaxLength(765)
                        .HasColumnType("character varying(765)")
                        .HasColumnName("spoken_languages");

                    b.Property<string>("Status")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("status");

                    b.Property<string>("Tagline")
                        .HasMaxLength(297)
                        .HasColumnType("character varying(297)")
                        .HasColumnName("tagline");

                    b.Property<string>("Title")
                        .HasMaxLength(105)
                        .HasColumnType("character varying(105)")
                        .HasColumnName("title");

                    b.Property<string>("Video")
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("video");

                    b.Property<decimal?>("VoteAverage")
                        .HasPrecision(4, 1)
                        .HasColumnType("numeric(4,1)")
                        .HasColumnName("vote_average");

                    b.Property<int?>("VoteCount")
                        .HasColumnType("integer")
                        .HasColumnName("vote_count");

                    b.ToTable("rawdata", (string)null);
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("integer");

                    b.Property<int>("MoviesId")
                        .HasColumnType("integer");

                    b.HasKey("GenresId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("GenreMovie");
                });

            modelBuilder.Entity("LanguageMovie", b =>
                {
                    b.Property<int>("MoviesId")
                        .HasColumnType("integer");

                    b.Property<int>("SpokenLanguagesId")
                        .HasColumnType("integer");

                    b.HasKey("MoviesId", "SpokenLanguagesId");

                    b.HasIndex("SpokenLanguagesId");

                    b.ToTable("LanguageMovie");
                });

            modelBuilder.Entity("CollectionMovie", b =>
                {
                    b.HasOne("data.BaseModels.Collection", null)
                        .WithMany()
                        .HasForeignKey("CollectionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("data.BaseModels.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CountryMovie", b =>
                {
                    b.HasOne("data.BaseModels.Country", null)
                        .WithMany()
                        .HasForeignKey("CountriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("data.BaseModels.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("data.BaseModels.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("data.BaseModels.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LanguageMovie", b =>
                {
                    b.HasOne("data.BaseModels.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("data.BaseModels.Language", null)
                        .WithMany()
                        .HasForeignKey("SpokenLanguagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
