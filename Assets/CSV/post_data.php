<?php
	$player_data = $_GET['player_data'];
	echo $player_data;
	
	$myFile = fopen ("data/CSV/saved_data.csv", "a") or die("Unable to open the file");
	
	fwrite($myFile, $player_data);
	fclose($myFile);

?>