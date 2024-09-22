healAmount = 5;

enemies = GetEnemies();
for key, val in pairs(enemies) do
	enemyHealth = val.GetCurrentHealth();
	val.SetCurrentHealth(enemyHealth + healAmount);
end

player = GetPlayer();
playerHealth = player.GetCurrentHealth();
player.SetCurrentHealth(playerHealth + healAmount);