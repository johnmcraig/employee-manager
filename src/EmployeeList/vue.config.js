// vue.config.js
module.exports = {
    outputDir: "./server/wwwroot/client",
    filenameHashing: false,
    publicPath: "./client/",
    pluginOptions: {
        sourceDir: "client/src/"
    }
}