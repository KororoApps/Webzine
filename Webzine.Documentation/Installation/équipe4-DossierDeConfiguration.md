{
"files.trimTrailingWhitespace": true,
"json.format.enable": false,
"editor.multiCursorModifier": "alt",
"editor.rulers": [80],
"markdown.updateLinksOnFileMove.enabled": "prompt",
// extension prettier
"prettier.printWidth": 80,
"prettier.proseWrap": "always",
"prettier.tabWidth": 4,
"prettier.trailingComma": "none",
// vie privée (désactivation de la télémétrie)
"telemetry.telemetryLevel": "off",
"workbench.iconTheme": "material-icon-theme",
"workbench.tree.indent": 20,
// le markdown est formaté via l'extension prettier :
// - lors de la sauvegarde du fichier md
// - avec des lignes de 80 caractères max
// - les espaces en fin de ligne ne sont pas supprimés
// car ils servent pour aller à la ligne en markdown
"[markdown]": {
"editor.defaultFormatter": "esbenp.prettier-vscode",
"editor.formatOnSave": true,
"files.trimTrailingWhitespace": false
}
}