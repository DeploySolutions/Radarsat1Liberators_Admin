# Radarsat1Liberators_Admin
Admin/Middleware for Radarsat1-Liberators (Space Apps Ottawa Hackathon 2019 project)


================
Project Overview
================
For 17 years, Canada's RADARSAT-1 earth observation satellite obtained radar images of the Earth's surface. Many of these images remain unprocessed and there is no easy way for interested users to examine the location and availability of currently unprocessed images.

During the Space Apps Ottawa 2019 hackathon, a team of four volunteers tackled a Canadian Space Agency/Natural Resource Canada challenge. The goal was to automate and improve searches on the Government of Canada EODMS system and then position RADARSAT-1 image locations and metadata on a world map, to allow users to easily view and filter against the whole Earth Observation data set.

================
Project Goals & Objectives
================

The goal of CSA and NRCan (Natural Resources Canada) is to make more RADARSAT-1 data available. Currently only 2% is processed and open to the public. To reduce high processing costs, the CSA would like to identify and prioritize datasets that could be useful for research purposes.

Because this project was a direct response to a hackathon challenge they posed, it has a single SMART objective: solve the challenge.

================
Project Results
================
Over a 48-hour period, our volunteer team (from several different companies, including Deploy) created a working website composed of:

    Front end search website using Vue.js and MapBox, served by node.js
    GeoJSON REST API middleware using C#
    Geospatial Metadata database using Postgres and PostGIS.
    GeoJSON extract and intake process from the EODMS system to our metadata database

The resulting proof of concept was well received by CSA and NRCan, subsequently winning the challenge category in Ottawa and then nationally.

This solution is the middleware/backend portion of the system. For the front end code, please go to https://github.com/adamsimonini/rs1 