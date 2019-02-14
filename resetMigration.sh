#!/bin/bash

projects=$(find . -type f -name *.csproj)
migrationProjects=$(find . -name Migrations)

count=$(wc -w <<< $projects)

if [ $count -eq "1" ]; then
    echo "Using project $projects"
    project=$migrationProjects
    projectDir=$(dirname $projects)
    echo;
else
    echo "More than one projects with migrations exists. Exiting..."
    exit 1
fi

latestFiles=$(find $project -type f | sort -n | grep -v "ContextModelSnapshot.cs" | grep -v ".Designer.cs" | tail -2 | cut -f2- -d" ")
fileName=${latestFiles#$project}
migrations=$(echo $fileName | sed -e "s/$*.cs$//" -e "s/^\/*//")
m=$(echo "${migrations%% *}")
migration=$(echo $m | sed -e "s/$*.cs$//")

latestMigrationFile=$(find $project -type f | sort -n | grep -v "ContextModelSnapshot.cs" | grep -v ".Designer.cs" | tail -1 | cut -f2- -d" ")
latestMigrationName=${latestMigrationFile#$project}
latestMigration=$(echo $latestMigrationName | sed -e "s/$*.cs$//" -e "s/^\/*//")

echo "Latest migration is $latestMigration"

read -p "Revert database to $migration (Y/n)? " -n 1 -r
echo;

if [[ $REPLY =~ ^[Yy]$ ]] || [[ -z $REPLY ]]; then
    echo "Reseting database to $migration."
    dotnet ef database update $migration --project $projectDir
    echo "Removing last migration."
    dotnet ef migrations remove --project $projectDir
fi
