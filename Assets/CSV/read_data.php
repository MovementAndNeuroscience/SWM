<?php
	$myFile = fopen("data/CSV/saved_data.csv", "r") or die ("Could not open the file");
	
	echo fread ($myFile, filesize("data/CSV/saved_data.csv"));
	
	fclose ($myFile);

?>