$files = Get-ChildItem "D:\Data\EODMS\centroids\"

foreach ($f in $files){
   
    Write-Host 'ogr2ogr -f "PostgreSQL" PG:"dbname=eodms_geo_metadata user=postgres password=sp@c3@pps" -nln public.catalog_centroids "'$f.FullName.Trim()'" -append'
}