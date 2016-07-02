/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 * @flow
 */

import React, { Component } from 'react';
import {
  AppRegistry,
  StyleSheet,
  Image,
  Text,
  View
} from 'react-native';
import Home from './Home';

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#F5FCFF',
  },
  welcome: {
    fontSize: 20,
    textAlign: 'center',
    margin: 10,
  },
  instructions: {
    textAlign: 'center',
    color: '#333333',
    marginBottom: 5,
  },
  flexboxStyle: {
    flex: 0,
    width: 150,
    backgroundColor: "gray"
  },
  verticalStackingStyle: {
    flex: 0,
    flexDirection: "column",
    left: 2,
    bottom: 2
  },
  horizontalStackingStyle: {
    flex: 0,
    flexDirection: "row",
    alignSelf: "flex-end",
    right: 2,
    bottom: 2
  },
  progressBarStyle: {
    alignSelf: "stretch",
    backgroundColor: "blue",
    height: 4,
    width: 75,
    bottom: 0
  },
  orangeText: {
    color: "orange",
    fontSize: 12
  }
});

var orangeText = styles.orangeText;
var flexboxStyle = styles.flexboxStyle;
var verticalStackingStyle = styles.verticalStackingStyle;
var horizontalStackingStyle = styles.horizontalStackingStyle;
var progressBarStyle = styles.progressBarStyle;

var Flexbox = React.createClass({
    displayName: "Flexbox",
    render: function () {
        return (
            <View style={this.props.style}>{this.props.children}</View>
        );
    }
});

var TextView = React.createClass({
    displayName: "TextView",
    render: function () {
        return (
            <Text style={this.props.style}>{this.props.children}</Text>
        );
    }
});

var ImageView = React.createClass({
    displayName: "ImageView",
    getInitialState: function () {
        return {};
    },
    render: function () {
        return (
            <Image
              height={this.props.height}
              width={this.props.width}
              source={{uri: this.props.uri}}
            />
        );
    }
});

var ProgressBarView = React.createClass({
    render: function () {
        return (
            <View style={progressBarStyle} />
        );
    }
});

var LockView = React.createClass({
    render: function () {
        var stateSuffix = this.props.isFocused ? "_focus" : "";

        var lockIconUris = {
            small: "assets/images/icons/lock_m" + stateSuffix + ".png",
            medium: "assets/images/icons/lock_m" + stateSuffix + ".png"
        };

        return (
            <ImageView uri={lockIconUris[this.props.tileSize]} />
        );
    }
});

var ReactTileView = React.createClass({
    getInitialState: function () {
        return {
            rating: {
              name: "PG-13"
            },
            isFocused: true,
            tileSize: "small",
            title: "foo title",
            tagline: "foo tagline",
            uri: "http://i2.cdn.turner.com/money/dam/assets/160620111803-john-oliver-brexit-1024x576.png"
        };
    },
    render: function () {
        var titleTextStyle = {
            color: "white",
            opacity: this.state.isFocused ? 1 : 0.7,
            fontSize: {
                small: 13,
                medium: 16
            }[this.state.tileSize]
        };

        var taglineTextStyle = {
            color: "white",
            opacity: this.state.isFocused ? 1 : 0.7,
            fontSize: {
                small: 9,
                medium: 12
            }[this.state.tileSize]
        };

        var ratingStyle = {
            color: "white",
            width: 40,
            fontSize: {
                small: 9,
                medium: 12
            }[this.state.tileSize],
            borderColor: "white",
            borderWidth: 1
        };

        var rating;
        if (this.state.isFocused && this.state.rating) {
            rating = <TextView style={ratingStyle}>{this.state.rating.name}</TextView>
        };

        return (
            <Flexbox style={flexboxStyle}>
                <ImageView uri={this.state.uri} />
                <Flexbox style={verticalStackingStyle}>
                    <TextView style={orangeText}>{this.state.violator}</TextView>
                    <TextView style={orangeText}>{this.state.umbrella}</TextView>
                    <TextView style={titleTextStyle}>{this.state.title}</TextView>
                    <TextView style={taglineTextStyle}>{this.state.tagline}</TextView>
                </Flexbox>
                <Flexbox style={horizontalStackingStyle}>
                    {rating}
                    <LockView tileSize={this.state.tileSize} isFocused={this.state.isFocused} />
                </Flexbox>
                <ProgressBarView />
            </Flexbox>
        );
    }
});


// <Text style={styles.instructions}>
//   Hello Hellowwww!
// </Text>
// <Home text="Hoho Home Button"></Home>

class AwesomeProject extends Component {
  render() {
    return (
      <View style={styles.container}>

        <ReactTileView></ReactTileView>

        <Text style={styles.instructions}>
          Press Cmd+R to reload,{'\n'}
          Cmd+D or shake for dev menu
        </Text>
      </View>
    );
  }
}


AppRegistry.registerComponent('AwesomeProject', () => AwesomeProject);
