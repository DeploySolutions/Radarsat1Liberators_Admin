$files = Get-ChildItem "D:\Data\EODMS\extents\"

foreach ($f in $files){
   
    Write-Host 'ogr2ogr -f "PostgreSQL" PG:"dbname=eodms_geo_metadata user=postgres password=sp@c3@pps" -nln public.catalog_extents "'$f.FullName.Trim()'" -append'
}