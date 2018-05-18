//
//  ViewController.swift
//  Assignment 1
//
//  Created by Matt on 15/03/2015.
//  Copyright (c) 2015 Matt. All rights reserved.
//

import UIKit

class ViewController: UIViewController {

    @IBOutlet weak var nextTargetLabel: UILabel!
    @IBOutlet weak var roundCountLabel: UILabel!
    @IBOutlet weak var currentScoreLabel: UILabel!
    @IBOutlet weak var gameSlider: UISlider!
    @IBOutlet weak var scoredLabel: UILabel!

    var targetValue: Int = 0
    var currentValue: Int = 0
    var score: Int = 0
    var round: Int = 0
    
    override func viewDidLoad() {
        super.viewDidLoad()
        view.backgroundColor = UIColor(patternImage: UIImage(named:"Background")!)
        
        currentScoreLabel.text = "0"
        roundCountLabel.text = "0"
        scoredLabel.text = "0"

        startNewRound()

        
        let thumbImageNormal = UIImage(named: "SliderThumb-Normal")
        gameSlider.setThumbImage(thumbImageNormal, forState: .Normal)
        let thumbImageHighlighted = UIImage(named: "SliderThumb-Highlighted")
        gameSlider.setThumbImage(thumbImageHighlighted, forState: .Highlighted)
        let insets = UIEdgeInsets(top: 0, left: 14, bottom: 0, right: 14)
        if let trackLeftImage = UIImage(named: "SliderTrackLeft") {
            let trackLeftResizable =
            trackLeftImage.resizableImageWithCapInsets(insets)
            gameSlider.setMinimumTrackImage(trackLeftResizable, forState: .Normal)
        }
        if let trackRightImage = UIImage(named: "SliderTrackRight") {
            let trackRightResizable =
            trackRightImage.resizableImageWithCapInsets(insets)
            gameSlider.setMaximumTrackImage(trackRightResizable, forState: .Normal)
        }
        
        // Do any additional setup after loading the view, typically from a nib.
    }

    @IBAction func Play(sender: AnyObject) {
    
        updateScore()
    }
    
    func startNewRound() {
        round++
        roundCountLabel.text = String(round)
        targetValue = 1 + Int(arc4random_uniform(100))
        currentValue = 50
        gameSlider.value = Float(currentValue)
        nextTargetLabel.text = String(targetValue)
    }
    
    func updateScore() {
        let difference = abs(targetValue - currentValue)
        let points = 100 - difference
        
        let currentScore = ceil(gameSlider.value * 100)
        
        scoredLabel.text = "\(currentScore)"
        
        score += points
        currentScoreLabel.text = String(score)
        startNewRound()
        
    }
    
    @IBAction func Reset(sender: AnyObject) {
        
        currentScoreLabel.text = "0"
        roundCountLabel.text = "0"
        round = 0
        score = 0
        
    }
    
    
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }


}

